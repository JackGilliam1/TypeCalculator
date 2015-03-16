var to_command = function(path, tool, args) {
            return path + tool + ' ' + args;
        },
        to_args = function(options, output) {
            var args = ' ' + options['path'] + ' ' + output;
              
              if(options['compilemode']) {
                    args += ' --compile ' + options['compilemode'];
              }
              if(options['workspace']) {
                    args += ' --workspace ' + options['workspace'];
              }
              if(options['profile']) {
                    args += ' --profile ' + options['profile'];
              }
              if(options['timeout']) {
                    args += ' --timeout ' + options['timeout'];
              }
              
              return args;
        };
        
module.exports = {
        init: function(options) {
            var gulp = require('gulp'),
                  shell = require('gulp-shell'),
                  prefix = options['prefix'] || 'st',
                  suites = options['suites'] || [],
                  stPath = options['st_path'] || 'src/packages/Storyteller2/tools/',
                  specs = options['specs'] || 'specs',
                  output = options['results'] || 'st-results/index.htm',
                  title = options['title'] || 'Storyteller Specs',
                  preTasks = options['pretasks'] || [],
                  
                  runCommand = 'start /B ' + to_command(stPath, 'ST.exe', ('run ' + to_args(options, output))),
                  specsCommand = 'start /B ' + to_command(stPath, 'ST.exe', ('specs ' + to_args(options, output) + ' --title ' + title));
                  openCommand = 'start ' + to_command(stPath, 'StoryTellerUI.exe', (to_args(options, output)));
            
            gulp.task(prefix + ':run', preTasks, function() {                
                return gulp.src('')
                           .pipe(shell([
                                runCommand
                           ]));
            });
            
            suites.forEach(function(suite) {
                gulp.task(prefix + ':run:' + suite.toLowerCase(), preTasks, function() {
                    return gulp.src('')
                               .pipe(shell([
                                    runCommand  + ' -w ' + suite
                               ]));
                });
            });
            
            gulp.task(prefix + ':open', preTasks, function() {                      
                return gulp.src('')
                           .pipe(shell([
                                openCommand
                           ]));
            });
            
            gulp.task(prefix + ':specs', preTasks, function() {
                 return gulp.src('')
                            .pipe(shell([
                                specsCommand
                            ]));
            });
        }
};