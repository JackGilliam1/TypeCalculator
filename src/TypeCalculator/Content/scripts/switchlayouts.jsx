var React = require('react');

module.exports =  React.createClass({
  displayName: 'SwitchLayoutsSection',
  propTypes: {
    defaultSelection: React.PropTypes.string,
    layouts: React.PropTypes.arrayOf(React.PropTypes.string),
    onLayoutSwitch: React.PropTypes.func.isRequired
  },
  handleChange: function(onLayoutSwitch) {
    return function(e) {
      onLayoutSwitch(e.target.value);
    };
  },
  render: function() {
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
      <div id="switchLayoutSection">
        <select defaultValue={defaultLayout} onChange={this.handleChange(this.props.onLayoutSwitch)}>
          {layoutOptions}
        </select>
      </div>
    );
  }
});