/**
 * @param {string} URL
 */
const getRawData = (URL) => {
    return fetch(URL)
       .then((response) => response.text())
       .then((data) => {
          return data;
       });
 };