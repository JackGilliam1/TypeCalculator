  var React = require('react');
  var TypeElement = require('typeelement.jsx');

  module.exports = React.createClass({
    render: function() {
      var elementTypes = this.props.types.map(function(type) {
        return (
          <TypeElement key={type} type={type} />
        );
      });
      return (
        <div className={this.props.className}>
          <h2>{this.props.columnTitle}</h2>
          <span className="types">
            <li id="count" className="type count">{'Type Count: ' + elementTypes.length}</li>
            {elementTypes}
          </span>
        </div>
      );
    }
  })