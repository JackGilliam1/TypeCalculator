var basePath = './src/TypeCalculator/Content/';

module.exports = {
    entry: basePath + 'app.js',
    output: {
        path: basePath + 'scripts',
        filename: 'bundle.js'
    },
    
    module: {
            loaders: [
                { test: /\.css$/, loader: 'style!css' },
                { test: /\.jsx$/, loader: 'jsx' },
                { test: /\.scss$/, loader: 'style!css!sass' }
            ]
    },
    
    resolve: {
            modulesDirectories: ['node_modules', 'scripts', 'styles', 'scripts/util', 'scripts/lib'],
            extensions: ['', '.js', '.jsx', '.css', '.sass']
    }
}