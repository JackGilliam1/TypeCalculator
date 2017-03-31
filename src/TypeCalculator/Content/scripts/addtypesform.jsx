var React = require('react');

module.exports =  React.createClass({
  displayName: 'AddTypesSection',
  propTypes: {
    defaultSelection: React.PropTypes.string,
    layouts: React.PropTypes.arrayOf(React.PropTypes.string),
    onAddTypes: React.PropTypes.func.isRequired
  },
  handleChange: function (onAddTypes) {
    return function(e) {
      onAddTypes(e.target.value);
    };
  },
  render: function () {
    var defaultLayout = this.props.defaultSelection || 'Column',
        layouts = this.props.layouts,
        layoutOptions;

    if(!layouts) {
      layouts = ['Table', 'Column'];
    }

    layoutOptions = layouts.map(function(layout) {
      return (
        <option key={layout} value={layout}>{layout + ' Layout'}</option>
      );
    });

    return (
      <div id="addTypesSection">
        <form action={handleChange}>
          <input id="typeOneInput" type="text" />
          <input id="typeTwoInput" type="text"/>
          <input id="strongAtkRad" type="radio" name="typeType" value="Strong Attack"/>
          <input id="strongDefRad" type="radio" name="typeType" value="Strong Defense" />
          <input id="strongDefRad" type="radio" name="typeType" value="Strong Defense" />
          <input id="typeSubmit" type="submit"/>
        </form>
      </div>
      );
  }
});