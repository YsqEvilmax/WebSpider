/// <binding Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/
var lodash = require('lodash');
var gulp = require('gulp');
var del = require('del');

var path = {
    libs: {
        angular: [
            './node_modules/angular2/bundles/angular2.js',
            './node_modules/angular2/bundles/router.js',
            './node_modules/angular2/bundles/angular2-polyfills.min.js',
            './node_modules/angular2/bundles/http.js'
        ],
        systemjs: [
            './node_modules/systemjs/dist/system.src.js'           
        ],
        rxjs: [
            './node_modules/rxjs/Rx.js'
        ],
        es6shim: [
            './node_modules/es6-shim/es6-shim.js'
        ]
    }
};

gulp.task('clean', () => {
    var cleansub = (sub) => {
        lodash.forEach(path.libs[sub], (file) => {
            del(file);
        });
    };
    cleansub('angular');
    cleansub('systemjs');
    cleansub('rxjs');
    cleansub('es6shim');
});

gulp.task('copy-libs', () => {
    var copysub = (sub) => {
        lodash.forEach(path.libs[sub], (file) => {
            gulp.src(file).pipe(gulp.dest('./Scripts'));
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