var React = require('react');

module.exports = React.createClass({
  displayName: 'EmptyTable',
  render: function() {
    return (
        <table className="stat-table">
          <thead className="header">
            <tr className="header-row row">
              <td className="header-cell cell">Type</td>
              <td className="header-cell cell none">None</td>
            </tr>
          </thead>
          <tbody className="body">
            <tr className="body-row row">
              <td className="type-cell cell none">None</td>
              <td className="body-cell cell">0</td>
            </tr>
          </tbody>
        </table>
    );
  }
});