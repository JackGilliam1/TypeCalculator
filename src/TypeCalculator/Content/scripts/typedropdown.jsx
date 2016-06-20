var $ = require('jquery.js');
var React = require('react');
var UpdateStatus = React.createClass({
  render: function() {
    return (
      <span id="statusBadge">{this.props.status}</span>
    );
  }
});

module.exports = React.createClass({
  displayName: "TypeDropdown",
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
  handleClickFor: function(onClick) {
    var self = this;
    return function(event) {
      onClick(event.target.value);
    };
  },
  toListItems: function(types, selectedType) {
    var lowerSelected = selectedType.toLowerCase();
    return types.map(function(type) {
      var lowerType = type.toLowerCase();
      return <option key={type} value={lowerType}>{type}</option>;
    });
  },
  render: function () {
    var defaultElement = <option key="None" value="none">None</option>,
        firstElements = [defaultElement],
        secondElements = [defaultElement],
        firstTypeChanged = this.handleClickFor(this.props.firstTypeChanged),
        secondTypeChanged = this.handleClickFor(this.props.secondTypeChanged),
        selectedFirstType = (this.props.selectedFirstType || 'None').toLowerCase(),
        selectedSecondType = (this.props.selectedSecondType || 'None').toLowerCase(),
        types = this.state.types;
    if(types) {
      firstElements = this.toListItems(types, selectedFirstType);
      secondElements = this.toListItems(types, selectedSecondType);
    }
    return (
      <div id="typeDropdown" className="centered at-top stretch">
        <select id="typeSelectOne" value={selectedFirstType} onChange={firstTypeChanged}>
          {firstElements}
        </select>
        <select id="typeSelectTwo" value={selectedSecondType} onChange={secondTypeChanged}>
          {secondElements}
        </select>
        <UpdateStatus status={this.props.status} />
      </div>
    );
  }
});