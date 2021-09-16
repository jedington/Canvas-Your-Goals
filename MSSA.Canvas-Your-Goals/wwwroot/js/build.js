// Fabric.js import, will expand on / use in future releases
var fabric = require('fabric').fabric, // or import { fabric } from 'fabric';
    http = require('http'),
    url = require('url'),
    PORT = 8124;

var server = http.createServer(function (request, response) {
    var params = url.parse(request.url, true);
    var canvas = new fabric.StaticCanvas(null, { width: 200, height: 200 });

    response.writeHead(200, { 'Content-Type': 'image/png' });

    canvas.loadFromJSON(params.query.data, function() {
        canvas.renderAll();

        var stream = canvas.createPNGStream();
        stream.on('data', function(chunk) {
            response.write(chunk);
        });
        stream.on('end', function() {
            response.end();
        });
    });
});

server.listen(PORT);


// ****** cache settings starts
/**
 * When `true`, object is cached on an additional canvas.
 * default to true
 * since 1.7.0
 * @type Boolean
 * @default
 */
objectCaching: objectCaching,

/**
 * When `true`, object properties are checked for cache invalidation. In some particular
 * situation you may want this to be disabled ( spray brush, very big pathgroups, groups)
 * or if your application does not allow you to modify properties for groups child you want
 * to disable it for groups.
 * default to false
 * since 1.7.0
 * @type Boolean
 * @default
 */
statefullCache = false,

/**
 * When `true`, cache does not get updated during scaling. The picture will get blocky if scaled
 * too much and will be redrawn with correct details at the end of scaling.
 * this setting is performance and application dependant.
 * default to false
 * since 1.7.0
 * @type Boolean
 * @default
 */
noScaleCache = true,

/**
 * List of properties to consider when checking if cache needs refresh
 * Those properties are checked by statefullCache ON ( or lazy mode if we want ) or from single
 * calls to Object.set(key, value). If the key is in this list, the object is marked as dirty
 * and refreshed at the next render
 * @type Array
 */
cacheProperties = (
    'fill stroke strokeWidth strokeDashArray width height stroke strokeWidth strokeDashArray' +
    ' strokeLineCap strokeLineJoin strokeMiterLimit fillRule backgroundColor'
).split(' '),

/**
 * When set to `true`, object's cache will be rerendered next render call.
 * @type Boolean
 * @default true
 */
dirty = true,

/**
 * When return `true`, force the object to have its own cache, even if it is inside a group
 * it may be needed when your object behave in a particular way on the cache and always needs
 * its own isolated canvas to render correctly.
 * since 1.7.12
 * @type function
 * @return false
 */
needsItsOwnCache = function() {
    return false;
},

/**
 * Pixel limit for cache canvases. 1Mpx , 4Mpx should be fine.
 * @since 1.7.14
 * @type Number
 * @default
 */
fabric.perfLimitSizeTotal = 2097152;

/**
 * Pixel limit for cache canvases width or height. IE fixes the maximum at 5000
 * @since 1.7.14
 * @type Number
 * @default
 */
fabric.maxCacheSideLimit = 4096;

/**
 * Lowest pixel limit for cache canvases, set at 256PX
 * @since 1.7.14
 * @type Number
 * @default
 */
fabric.minCacheSideLimit = 256;
// ****** cache settings ends


// allow zooming
canvas.on('mouse:wheel', function(opt) {
    var delta = opt.e.deltaY;
    var zoom = canvas.getZoom();
    zoom *= 0.999 ** delta;
    if (zoom > 20) zoom = 20;
    if (zoom < 0.01) zoom = 0.01;
    canvas.zoomToPoint({ x: opt.e.offsetX, y: opt.e.offsetY }, zoom);
    opt.e.preventDefault();
    opt.e.stopPropagation();
    var vpt = this.viewportTransform;
    if (zoom < 400 / 1000) {
        vpt[4] = 200 - 1000 * zoom / 2;
        vpt[5] = 200 - 1000 * zoom / 2;
    }
     else {
        if (vpt[4] >= 0) {
            vpt[4] = 0;
        }
        else if (vpt[4] < canvas.getWidth() - 1000 * zoom) {
            vpt[4] = canvas.getWidth() - 1000 * zoom;
        }
        if (vpt[5] >= 0) {
            vpt[5] = 0;
        }
        else if (vpt[5] < canvas.getHeight() - 1000 * zoom) {
            vpt[5] = canvas.getHeight() - 1000 * zoom;
        }
    }
});