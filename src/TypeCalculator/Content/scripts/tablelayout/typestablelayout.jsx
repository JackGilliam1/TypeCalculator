require('typestablelayout.scss');

var React = require('react'),
    $ = require('jquery'),
    EmptyTable = require('tablelayout/emptytable.jsx'),
    TableHeaderRows = require('tablelayout/tableheaderrows.jsx'),
    TableBodyRows = require('tablelayout/tablebodyrows.jsx');

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
  componentWillMount: function() {
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
    var stats = this.state.stats;

    if(!stats) {
      return <EmptyTable />;
    }

    return (
      <div id="rightSection" className="main-section">
        <table className="stat-table">
          <TableHeaderRows stats={stats} />
          <TableBodyRows selectedFirstType={this.props.selectedFirstType || 'None'} selectedSecondType={this.props.selectedSecondType || 'None'} stats={stats} onCellClick={this.props.onCellClick} />
        </table>
      </div>
    );
  }
});