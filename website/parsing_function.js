/**
 * @param {string} URL
 */
const request = require("request-promise");
const cheerio = require("cheerio");

request("https://www.usna.edu/Users/cs/roche/courses/s15si335/proj1/files.php%3Ff=names.txt.html", (error, response, html) => 
{
    if(!error && response.statusCode == 200){
        const $= cheerio.load(html);
    }
})