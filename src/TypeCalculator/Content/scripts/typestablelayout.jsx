var React = require('react');
var $ = require('jquery');

module.exports = React.createClass({
  propTypes: {
    selectedFirstType: React.PropTypes.string,
    selectedSecondType: React.PropTypes.string,
    onCellClick: React.PropTypes.func.isRequired
  },
  getInitialState: function() {
    return {
      stats: undefined
    };
  },
  componentDidMount: function() {
    var self = this;
    if(self.stats) {
      return;
    }
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
        selectedFirstType = this.props.selectedFirstType || 'None',
        selectedSecondType = this.props.selectedSecondType || 'None',
        onClick = this.props.onCellClick;

    if(!stats) {
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
              <td className="cell none">None</td>
              <td className="body-cell cell">0</td>
            </tr>
          </tbody>
        </table>
      );
    }
    var statHeaders = stats.map(function(stat) {
          return (
            <td key={stat.ElementType} className={"type-cell header-cell cell " + stat.ElementType.toLowerCase()}>{stat.ElementType}</td>
          );
        }),
        statBodyRows = stats.map(function(stat) {
          var lowerStat = stat.ElementType.toLowerCase(),
              lowerFirstType = selectedFirstType.toLowerCase(),
              lowerSecondType = selectedSecondType.toLowerCase(),
              isSelected = lowerStat === lowerFirstType,
              className = 'body-row row clickable' + (isSelected ? ' selected' : '');


          var multipliers = stat.Stats.map(function(elementStat) {
            var className = 'body-cell cell',
                onCellClick = function(callback, typeOne, typeTwo) {
                  return function(e) {
                    callback(typeOne, typeTwo);
                  };
                }(onClick, stat.ElementType, elementStat.ElementType),
                multiplier = elementStat.Multiplier;


            if(elementStat.ElementType.toLowerCase() === lowerSecondType) {
              className += ' vert-selected';
            }
            if(isSelected) {
              className += ' horiz-selected';
            }

            if(elementStat.ElementType.toLowerCase() === lowerSecondType || isSelected) {
              className += ' selected';
            }
            if(multiplier === 2) {
              className += ' strong';
            }
            else if(multiplier === 0.5) {
              className += ' weak';
            }
            else if(multiplier === 0) {
              className += ' immune';
            }
            return (
              <td key={elementStat.ElementType} className={className} element={elementStat.ElementType} onClick={onCellClick}>{multiplier}</td>
            );
          });

          return (
            <tr key={stat.ElementType} className={className}>
              <td key={stat.ElementType} className={"type-cell cell " + stat.ElementType.toLowerCase()}>{stat.ElementType}</td>
              {multipliers}
            </tr>
          );
        });

    return (
      <div id="rightSection" className="main-section">
        <table className="stat-table">
          <thead className="header">
            <tr className="header-row row">
              <td className="type-cell header-cell cell">Type</td>
              {statHeaders}
            </tr>
          </thead>
          <tbody className="body">
            {statBodyRows}
          </tbody>
        </table>
      </div>
    );
  },
  componentDidUpdate: function() {
    
  }
});