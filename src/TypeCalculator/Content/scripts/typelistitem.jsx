  var React = require('react');
  module.exports = React.createClass({
    render: function() {
        var elementType = this.props.type;
        return (
          <li key={elementType} className={"type " + elementType.toLowerCase().split(' ')[0]}>{elementType}</li>
        ); 
    }
  });