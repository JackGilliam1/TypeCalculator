var React = require('react');
var $ = require('jquery');

module.exports = React.createClass({
  render: function() {
    return (
      <table>
        <thead>
          <tr>
            <td>Some Header</td>
            <td>Some Other Header</td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Data One</td>
            <td>Data Two</td>
          </tr>
        </tbody>
      </table>
    );
  }
});