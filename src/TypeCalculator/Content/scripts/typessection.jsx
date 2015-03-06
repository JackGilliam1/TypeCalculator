var React = require('react');
var $ = require('jquery');
module.exports = React.createClass({
  displayName: 'TypesSection',
  getInitialState: function() {
    return {
      types: ["None", "NoneTwo"]
    };
  },
  componentDidMount: function () {
    var self = this;
    $.ajax('types/getTypes', {
          data: {},
          success: function(data) {
            if(self.isMounted()) {
              self.setState({
                types: data.Types
              });
            } 
          }
        });
  },
  render: function() {
    var firstElements = [],
        secondElements = [],
        firstTypeChanged = this.props.firstTypeChanged,
        secondTypeChanged = this.props.secondTypeChanged,
        selectedFirstType = this.props.selectedFirstType.toLowerCase(),
        selectedSecondType = this.props.selectedSecondType.toLowerCase();


    if(this.state.types) {
      firstElements = this.state.types.map(function(type) {
                var className = "clickable selection-item";
                if(type.toLowerCase() === selectedFirstType) {
                   className += " selected";
                }
                return <li key={type} className={className} onClick={firstTypeChanged} value={type.toLowerCase()}>{type}</li>;
              });
      secondElements = this.state.types.map(function(type) {
                var className = "clickable selection-item";
                if(type.toLowerCase() === selectedSecondType) {
                   className += " selected";
                }
                return <li key={type} className={className} onClick={secondTypeChanged} value={type.toLowerCase()}>{type}</li>;
              });
    }
    return (
      <span>
        <div className="top">
          <li className="selection-item selection-header">First</li>
          {firstElements}
        </div>
        <div className="bottom">
          <li className="selection-item selection-header">Second</li>
          {secondElements}
        </div>
      </span>
    );
  }
});