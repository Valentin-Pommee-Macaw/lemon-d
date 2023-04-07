const { series, src, dest } = require('gulp');
const concat = require('gulp-concat');
const minify = require('gulp-minify');
const jshint = require('gulp-jshint');
const stylish = require('jshint-stylish');
const sass = require('gulp-sass')(require('sass'));
const cleanCSS = require('gulp-clean-css');

const javaScriptSrc = 'Lemon-d.local/**/Scripts/**/*.js';
const javaScriptDest = 'Lemon-d.local/wwwroot/js/';

const scssSrc = 'Lemon-d.local/**/Lemon-d.scss';
const cssDest = 'Lemon-d.local/wwwroot/css';
const cssMinDest = 'Lemon-d.local/wwwroot/css/min';

function defaultTask (cb) {
    cb();
}

function handleError(err) {
    console.log(err.toString());
    this.emit('end');
}

exports.concatJS = function concatJS(cb) {
    src(javaScriptSrc)
    .pipe(jshint(
        {strict: false, white: false}
    ))
    .pipe(concat('lemon-d.js'))
    .on('error', handleError)
    .pipe(jshint.reporter(stylish))
    .pipe(minify())
    .pipe(dest(javaScriptDest));
    cb();
}

exports.concatSCSS = async function concatSCSS(cb) {
    src(scssSrc)
    .pipe(sass().on('error', sass.logError))
    .pipe(dest(cssDest));
    cb();
}

exports.minifySCSS = async function minifySCSS(cb) {
    src(scssSrc)
    .pipe(sass().on('error', sass.logError))
    .pipe(cleanCSS(/*{compatibility: 'ie8'}*/))
    .pipe(dest(cssMinDest));
    cb();
}

exports.default = series(defaultTask, exports.concatJS, exports.concatSCSS, exports.minifySCSS);
exports.scss = series(exports.concatSCSS, exports.minifySCSS);