var $ = require('jquery.js');
var React = require('react');

module.exports =  React.createClass({
  displayName: 'AddTypesSection',
  propTypes: {
    onAddTypes: React.PropTypes.func.isRequired,
    selectedAddType: React.PropTypes.string,
    selectedAddTypeChange: React.PropTypes.func.isRequired
  },
  handleSubmit: function (onAddTypes) {
    return function (e) {
      var typeOne = $('#addTypesSection .addTypeOneInput')[0].value;
      var typeTwo = $('#addTypesSection .addTypeTwoInput')[0].value;
      var typeType = $('#addTypesSection .addTypeTypeInput option:selected')[0].value;
      if (typeOne && typeTwo) {
        onAddTypes(typeOne, typeTwo, typeType);
      }
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
        <label for="typeOneInput">Type One</label>
        <input name="typeOneInput" className={'addTypesInput addTypeOneInput'} type="text" /><br />
        <label for="typeTwoInput">Type Two</label>
        <input name="typeTwoInput" className={'addTypesInput addTypeTwoInput'} type="text"/><br />
        <label for="typeType">Type Of Damage</label>
        <select name="typeType" className={'addTypesInput addTypeTypeInput'}
                value={selectedAddType} onChange={this.handleChange(this.props.selectedAddTypeChange)}>
          <option key="strongAtk" value="StrongAttack">Strong Attack Against</option>
          <option key="strongDefRad" value="StrongDefense">Strong Defense Against</option>
          <option key="weakAtkRad" value="WeakAttack" >Weak Attack Against</option>
          <option key="weakDefRad" value="WeakDefense" >Weak Defense Against</option>
          <option key="immuneRad"  value="ImmuneDefense" >Immune Against</option>
        </select><br/>
        <button id="typeSubmit" onClick={this.handleSubmit(this.props.onAddTypes)}>Submit</button>
      </div>
      );
  }
});