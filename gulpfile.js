var gulp = require('gulp'),
      storyTellerSetup = require('./gulp-storyteller.js');

gulp.task('default', ['ripple:restore', 'build', 'assemblyInfo', 'runwebpack', 'startmongo', 'st:run']);

gulp.task('build', ['ripple:restore'], function() {
    var msbuild = require('gulp-msbuild'),
          assemblyInfo = require('gulp-dotnet-assembly-info');
          
    return gulp.src('./src/TypeCalculator.sln')
                .pipe(msbuild({
                    stdout: true,
                    targets: ['Build'],
                    configuration: 'Debug'
                }));
});

gulp.task('runwebpack', function() {
    var shell = require('gulp-shell');
    
    return gulp.src('')
                .pipe(shell([
                    'webpack'
                ]));
});

gulp.task('startmongo', function() {
    var shell = require('gulp-shell');
    
    return gulp.src('')
               .pipe(shell([
                   'start startmongo.sh'
               ]));
});

gulp.task('ripple:restore', function(otherThings) {
    var shell = require('gulp-shell');
    
    return gulp.src('')
                .pipe(shell([
                    'ripple restore'
                ]));
});

storyTellerSetup.init({
    path: 'src/TypeCalculator.StoryTeller',
    compilemode: 'Debug',
    pretasks: ['runwebpack', 'startmongo'],
    suites: ['Main']
});