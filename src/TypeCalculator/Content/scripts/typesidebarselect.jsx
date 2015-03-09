var $ = require('jquery.js');
var React = require('react');

module.exports = React.createClass({
  displayName: "TypeDropdown",
  propTypes: {
   types: React.PropTypes.arrayOf(React.PropTypes.string),
   selectedFirstType: React.PropTypes.string,
   selectedSecondType: React.PropTypes.string,
   firstTypeChanged: React.PropTypes.func.isRequired,
   secondTypeChanged: React.PropTypes.func.isRequired
  },
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
  handleClickFor: function(onClick, selectedTypePropertyName) {
    var self = this;
    return function(event) {
      onClick(event.target.value);
    };
  },
  toListItems: function(types, selectedType) {
    var lowerSelected = selectedType.toLowerCase();
    return types.map(function(type) {
      var className = "clickable selection-item",
          lowerType = type.toLowerCase();
      if(lowerType === lowerSelected) {
         className += " selected";
      }
      return <option key={type} value={lowerType} className={className}>{type}</option>;
    });
  },
  render: function () {
    var defaultElement = <option key="None" value="none">None</option>,
        firstElements = [defaultElement],
        secondElements = [defaultElement],
        types = this.state.types,
        firstTypeChanged = this.handleClickFor(this.props.firstTypeChanged, 'selectedFirstType'),
        secondTypeChanged = this.handleClickFor(this.props.secondTypeChanged, 'selectedSecondType'),
        selectedFirstType = (this.props.selectedFirstType || 'None').toLowerCase(),
        selectedSecondType = (this.props.selectedSecondType || 'None').toLowerCase();
    if(types) {
      firstElements = this.toListItems(types, selectedFirstType);
      secondElements = this.toListItems(types, selectedSecondType);
    }
    return (
      <span id="sidebarSelect" className="sidebar">
        <select id="sidebarSelectOne"
           className="sidebar-section"
           defaultValue={selectedFirstType}
           value={selectedFirstType}
           size={firstElements.length}
           onChange={firstTypeChanged}>
          {firstElements}
        </select>
        <select id="sidebarSelectTwo" className="sidebar-section"
           defaultValue={selectedSecondType}
           value={selectedSecondType}
           size={secondElements.length}
           onChange={secondTypeChanged}>
          {secondElements}
        </select>
      </span>
    );
  }
});