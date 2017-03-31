var React = require('react');

module.exports =  React.createClass({
  displayName: 'AddTypesSection',
  propTypes: {
    onAddTypes: React.PropTypes.func.isRequired,
    selectedAddType: React.PropTypes.string,
    selectedAddTypeChange: React.PropTypes.func.isRequired
  },
  handleSubmit: function (onAddTypes) {
    return function(e) {
      onAddTypes(e.target.value);
    };
  },
  handleChange: function (onTypeChange) {
    return function (e) {
      onTypeChange(e.target.value);
    };
  },
  render: function () {
    var selectedAddType = this.props.selectedAddType || 'strongAtk';
    return (
      <div id="addTypesSection" className={'addTypesSection'}>
        <input id="typeOneInput" className={'addTypesInput'} type="text" /><br />
        <input id="typeTwoInput" className={'addTypesInput'} type="text"/><br />
        <select id="typeType" value={selectedAddType} onChange={this.handleChange(this.props.selectedAddTypeChange)}>
          <option key="strongAtk" value="strongAtk">Strong Attack Against</option>
          <option id="strongDefRad" value="strongDef">Strong Defense Against</option>
          <option id="weakAtkRad" value="weakAtk" >Weak Attack Against</option>
          <option id="weakDefRad" value="weakDef" >Weak Defense Against</option>
          <option id="immuneRad"  value="immune" >Immune Against</option>
        </select>
        <button id="typeSubmit">Submit</button>
      </div>
      );
  }
});