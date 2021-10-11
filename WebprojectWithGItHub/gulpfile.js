

// Before using make sure you have do an 'npm install' to get all the dependencies.
'use strict'

const gulp = require('gulp'),
   
    concat = require('gulp-concat'),
minify = require('gulp-minify')

/*// PostCSS - to further optimise the final output CSS files.
const mergeLongHand = require('postcss-merge-longhand'), // Merges long-hand form of border, margin and padding
    removeEmpty = require('postcss-discard-empty'), // Remove empty code blocks in css files.
    removeComments = require('postcss-discard-comments'), // Remove comments.
    removeDuplicate = require('postcss-discard-duplicates') // Remove duplicate css blocks

const postCssPlugins = [mergeLongHand, removeEmpty, removeComments, removeDuplicate]*/


// Main site JS bundle
gulp.task('js-bundle', function () {
    return gulp
      //  .src('./scripts/src/**/*.js')
        .src('./wwwroot/js/*.js')
        .pipe(concat('bundle.js'))
        .pipe(minify())
        .pipe(gulp.dest('./wwwroot/app'))
})
// Main site css bundle
gulp.task('css-bundle', function () {
    return gulp
        //  .src('./scripts/src/**/*.js')
        .src('./wwwroot/css/*.css')
        .pipe(concat('bundle.css'))
        .pipe(minify())
        .pipe(gulp.dest('./wwwroot/css-min/'))
})

gulp.task(
    'js', 
    gulp.series([
        'js-bundle'
    ])
)

gulp.task(
    'style',
    gulp.series([
        'css-bundle'
    ])
)

gulp.task('default', gulp.series(['js','style']))