$(document).ready(function () {
  var TypeDropdown = React.createClass({
    displayName: "TypeDropdown",
    componentDidMount: function () {
      $.get('types/getTypes', function (data) {
          if (this.isMounted()) {
            this.setState({
              types: data.types
            });
          }
      }).bind(this);
    },
    onOneChange: function() {
      alert('oh no one');
    },
    onTwoChange: function () {
      alert('oh no two');
    },
    render: function () {
      var elements = this.state.types.map(function(type) {
        return React.createElement("option", { value: type.toLowerCase() }, type);
      });
      return (
        React.createElement("span", { id: "typeDropdown" },
          React.createElement("select", { id: "typeSelectOne", defaultValue: "None", onChange: this.onOneChange },
            elements),
          React.createElement("select", { id: "typeSelectTwo", defaultValue: "None", onChange: this.onTwoChange },
            React.createElement("option", { value: "None" }, "None"),
            React.createElement("option", { value: "NoneTwo" }, "NoneTwo")))
      );
    }
  });

  React.render(React.createElement(TypeDropdown, null), document.getElementById('typeDropdown'));
});
