var React = require('react');
var TypeListItem = require('typelistitem.jsx');

module.exports = React.createClass({
  displayName: 'TypeColumn',
  propTypes: {
    className: React.PropTypes.string,
    columnTitle: React.PropTypes.string,
    types: React.PropTypes.arrayOf(React.PropTypes.string).isRequired
  },
  emptyColumn: <TypeListItem key="None" type="None" />,
  render: function() {
    var className = this.props.className,
        columnTitle = this.props.columnTitle,
        elementTypes = this.props.types.map(function(type) {
          return (
            <TypeListItem key={type} type={type} />
          );
        });

    return (
      <span className={className}>
        <h2>{columnTitle}</h2>
        <div className="types">
          <li id="count" className="count">{'Type Count: ' + elementTypes.length}</li>
          {elementTypes.length > 0 ? elementTypes : this.emptyColumn}
        </div>
      </span>
    );
  }
});