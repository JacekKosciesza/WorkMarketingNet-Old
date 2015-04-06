/// <binding AfterBuild='less, copy' />
/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/

var mozjpeg = require('imagemin-mozjpeg');

module.exports = function (grunt) {
	grunt.initConfig({
		bower: {
			install: {
				options: {
					targetDir: "wwwroot/lib",
					layout: "byComponent",
					cleanTargetDir: true
				}
			}
		},
		less: {
			development: {
				options: {
					paths: ["Assets"],
				},
				files: { "wwwroot/css/themes/default.css": "assets/less/themes/default.less" }
			},
		},
		imagemin: {
			static: {
				options: {
					optimizationLevel: 3,
					svgoPlugins: [{ removeViewBox: false }],
					use: [mozjpeg()]
				},
				files: {
					'wwwroot/images/logos/WorkMarketingNet/logo-512x512.png': 'assets/images/logos/WorkMarketingNet/logo-512x512.png' // 'destination': 'source'
				}
			},
			dynamic: {
				files: [{
					expand: true,                  // Enable dynamic expansion
					cwd: 'assets/images/',         // Src matches are relative to this path
					src: ['**/*.{png,jpg,gif}'],   // Actual patterns to match
					dest: 'wwwroot/images/'        // Destination path prefix
				}]
			}
		},
		copy: {
			main: {
				files: [
				  // includes files within path
				  { expand: true, flatten: true, src: ['assets/polymer/*'], dest: 'wwwroot/polymer/', filter: 'isFile' }
				],
			},
		},
	});
	
	grunt.loadNpmTasks("grunt-bower-task");
	grunt.loadNpmTasks('grunt-newer');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks("grunt-contrib-less");
	grunt.loadNpmTasks('grunt-contrib-imagemin');

	grunt.registerTask("default", ["bower:install"]);
	grunt.registerTask('imgopt', ['newer:imagemin:static']);
};