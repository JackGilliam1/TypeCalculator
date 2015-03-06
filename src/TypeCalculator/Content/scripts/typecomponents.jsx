var $ = require('jquery.js');
var React = require('react');
var UpdateStatus = React.createClass({
  render: function() {
    return (
      <span id="statusBadge">{this.props.status}</span>
    );
  }
});

var TypeDropdown = React.createClass({
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
  render: function () {
    var elements = [];

    if(this.state.types) {
      elements = this.state.types.map(function(type) {
                return <option key={type} value={type.toLowerCase()}>{type}</option>;
              });
    }
    return (
      <span id="typeDropdown">
        <select id="typeSelectOne" defaultValue="None" onChange={this.props.firstTypeChanged}>
          {elements}
        </select>
        <select id="typeSelectTwo" defaultValue="None" onChange={this.props.secondTypeChanged}>
          {elements}
        </select>
        <UpdateStatus status={this.props.status} />
      </span>
    );
  }
});
module.exports = TypeDropdown;