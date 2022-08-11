/**
 * @param {string} URL
 */
const get_data = (URL) => {
    return fetch(URL)
       .then((response) => response.text())
       .then((data) => {
          return data;
       });
 };
