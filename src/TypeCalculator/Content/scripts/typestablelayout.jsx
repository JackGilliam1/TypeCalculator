var React = require('react');
var $ = require('jquery');

module.exports = React.createClass({
  getInitialState: function() {
    return {
      stats: undefined
    };
  },
  componentDidMount: function() {
    var self = this;
    $.ajax('types/getTypesTable', {
            data: {},
            success: function(data) {
              if(self.isMounted()) {
                self.setState({
                  stats: data.Stats
                });
              }
            }
          });
  },
  render: function() {
    var stats = this.state.stats,
        self = this;
    if(!stats) {
      return (
        <table><tbody><tr><td>Nothing Selected</td></tr></tbody></table>
      );
    }
    var statHeaders = stats.map(function(stat) {
          return (
            <td>{stat.ElementType}</td>
          );
        }),
    statRows = stats.map(function(stat) {
      var multipliers = stat.Stats.map(function(elementStat) {
        return (
          <td>{elementStat.Multiplier}</td>
        );
      });
      return (
        <tr>
          <td key={stat.ElementType}>{stat.ElementType}</td>
          {multipliers}
        </tr>
      );
    });

    return (
      <table>
        <thead>
          <tr>
            <td>Type</td>
            {statHeaders}
          </tr>
        </thead>
        <tbody>
          {statRows}
        </tbody>
      </table>
    );
  }
});