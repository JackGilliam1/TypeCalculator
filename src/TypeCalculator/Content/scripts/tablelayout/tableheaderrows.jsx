var React = require('react');

module.exports = React.createClass({
  displayName: 'TableHeaderRows',
  propTypes: {
    stats: React.PropTypes.arrayOf(React.PropTypes.object).isRequired,
  },
  render: function() {
    var currentCell = 0,
        statHeaders = this.props.stats.map(function(stat) {
          currentCell += 1;
          return (
            <td key={stat.ElementType} className={"type-cell header-cell cell type " + stat.ElementType.toLowerCase() + " cell-" + currentCell }>{stat.ElementType}</td>
          );
        });

    return (
        <thead className="header">
          <tr className="header-row row">
            <td className="type-cell header-cell cell">Type</td>
            {statHeaders}
          </tr>
        </thead>
    );
  }
});