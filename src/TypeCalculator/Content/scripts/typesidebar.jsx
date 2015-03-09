var React = require('react');
var $ = require('jquery');
module.exports = React.createClass({
  displayName: 'SidebarList',
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
      onClick(event.target.outerText);
    };
  },
  toListItems: function(types, onClick, selectedType) {
    var lowerSelected = selectedType.toLowerCase();
    return types.map(function(type) {
                var className = "clickable selection-item",
                    lowerType = type.toLowerCase();
                if(lowerType === lowerSelected) {
                   className += " selected";
                }
                return <li key={type} className={className} onClick={onClick} value={lowerType}>{type}</li>;
              });
  },
  render: function() {
    var defaultElement = <li key="None" className="clickable selection-item selected" value="none">None</li>,
        firstElements = [defaultElement],
        secondElements = [defaultElement],
        types = this.state.types,
        onFirstTypeClicked = this.handleClickFor(this.props.firstTypeChanged, 'selectedFirstType'),
        onSecondTypeClicked = this.handleClickFor(this.props.secondTypeChanged, 'selectedSecondType')
        selectedFirstType = this.props.selectedFirstType || 'None',
        selectedSecondType = this.props.selectedSecondType || 'None';

    if(types) {
      firstElements = this.toListItems(types, onFirstTypeClicked, selectedFirstType);
      secondElements = this.toListItems(types, onSecondTypeClicked, selectedSecondType);
    }
    return (
      <span id="sidebarList" className="sidebar">
        <div className="sidebar-section">
          <li className="selection-item selection-header">First</li>
          {firstElements}
        </div>
        <div className="sidebar-section">
          <li className="selection-item selection-header">Second</li>
          {secondElements}
        </div>
      </span>
    );
  }
});