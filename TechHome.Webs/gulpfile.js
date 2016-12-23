/// <binding BeforeBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
var lodash = require('lodash');
var gulp = require('gulp');
var del = require('del');

var path = {
    libs: {
        angular: {
            from: './node_modules/angular2/bundles/',
            to:'./Scripts/',
            files:[
            'angular2.js',
            'router.js',
            'angular2-polyfills.js',
            'http.js'
            ]},
        systemjs: {
            from: './node_modules/systemjs/dist/',
            to: './Scripts/',
            files: ['system.src.js']           
        },
        rxjs: {
            from: './node_modules/rxjs/',
            to: './Scripts/',
            files: [
            'Rx.js',
            'Rx.js.map'
        ]},
        es6shim: {
            from: './node_modules/es6-shim/',
            to: '/Scripts/',
            files: ['es6-shim.js']
        }
    }
};

gulp.task('clean', () => {
    var cleansub = (sub) => {
        lodash.forEach(path.libs[sub].files, (file) => {
            del(path.libs[sub].to + file);
        });
    };
    cleansub('angular');
    cleansub('systemjs');
    cleansub('rxjs');
    cleansub('es6shim');
});

gulp.task('copy-libs', () => {
    var copysub = (sub) => {
        lodash.forEach(path.libs[sub].files, (file) => {
            gulp.src(path.libs[sub].from + file)
                .pipe(gulp.dest(path.libs[sub].to));
        });
    };
    copysub('angular');
    copysub('systemjs');
    copysub('rxjs');
    copysub('es6shim');
});

gulp.task('default', ['copy-libs'], function () {
    // place code for your default task here
});