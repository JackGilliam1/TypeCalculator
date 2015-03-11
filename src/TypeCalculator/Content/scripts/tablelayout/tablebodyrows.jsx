var React = require('react'),
    $ = require('jquery');

module.exports = React.createClass({
    displayName: 'TableBodyRows',
    propTypes: {
      stats: React.PropTypes.arrayOf(React.PropTypes.object).isRequired,
      onCellClick: React.PropTypes.func.isRequired
    },
    shouldComponentUpdate: function(nextProps) {
      return this.props.selectedFirstType !== nextProps.selectedFirstType || this.props.selectedSecondType !== nextProps.selectedSecondType;
    },
    render: function() {
      var selectedFirstType = this.props.selectedFirstType,
          selectedSecondType = this.props.selectedSecondType,
          onClick = this.props.onCellClick,
          bodyRows = this.props.stats.map(function(stat) {
              var lowerStat = stat.ElementType.toLowerCase(),
                  lowerFirstType = selectedFirstType.toLowerCase(),
                  lowerSecondType = selectedSecondType.toLowerCase(),
                  isSelected = lowerStat === lowerFirstType,
                  className = 'body-row row clickable' + (isSelected ? ' selected' : ''),
                  currentCell = 0;

              var multipliers = stat.Stats.map(function(elementStat) {
                var className = 'body-cell cell',
                    onCellClick = function(callback, typeOne, typeTwo) {
                      return function(e) {
                        callback(typeOne, typeTwo);
                      };
                    }(onClick, stat.ElementType, elementStat.ElementType),
                    multiplier = elementStat.MultiplierStrength.Multiplier,
                    lowerElementType = elementStat.ElementType.toLowerCase();

                if(lowerElementType === lowerSecondType) {
                  className += ' vert-selected';
                }
                if(isSelected) {
                  className += ' horiz-selected';
                }
                currentCell += 1;
                className += ' ' + elementStat.MultiplierStrength.Strength.toLowerCase();

                if(lowerElementType === lowerSecondType || isSelected) {
                  className += ' selected';
                }
                className += ' cell-' + currentCell;
                return (
                  <td key={elementStat.ElementType} className={className} onClick={onCellClick}>{multiplier}</td>
                );
              });

              return (
                <tr key={stat.ElementType} className={className}>
                  <td key={stat.ElementType} className={"type-cell cell type " + stat.ElementType.toLowerCase()}>{stat.ElementType}</td>
                  {multipliers}
                </tr>
              );
          });

          console.log('updating');

        return (
          <tbody className="stats-table-body">
            {bodyRows}
          </tbody>
        );
    },
    applyHover: function() {
      //hover colors
      $('.row').hover(function(e) {
        $('.row.hover').removeClass('hover');
        if($(e.currentTarget).attr('class').indexOf('header-row') == -1) {
          $(e.currentTarget).addClass('hover');
        }
      });
      $('.cell').hover(function(e) {
        $('.cell.hover').removeClass('hover');
        var cellColumnClass = $(e.currentTarget).attr('class');
        if(cellColumnClass.indexOf('cell-') != -1) {
          $('.' + cellColumnClass.substring(cellColumnClass.indexOf('cell-'))).addClass('hover');
        }
      });
    },
    componentDidMount: function() {
      this.applyHover();
    },
    componentDidUpdate: function() {
      this.applyHover();
    }
});