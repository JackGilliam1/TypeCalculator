﻿var React = require('react');
var $ = require('jquery');

var TypeDropdown = require('typedropdown.jsx');
var Sidebar = require('typesidebar.jsx');
var TypesColumnLayout = require('typescolumnlayout.jsx');
var TypesTableLayout = require('typestablelayout.jsx');

var SwitchLayoutsSection = React.createClass({
  handleChange: function(onLayoutSwitch) {
    return function(e) {
      onLayoutSwitch(e.target.value);
    };
  },
  render: function() {
    return (
      <span id="switchLayoutSection">
        <select defaultValue="Column" onChange={this.handleChange(this.props.onLayoutSwitch)}>
          <option value="Table">Table Layout</option>
          <option value="Column">Column Layout</option>
        </select>
      </span>
    );
  }
});

var TypeCalculator;

module.exports = TypeCalculator = React.createClass({
  getInitialState: function() {
    var defaultTypes = [];
    return {
      selectedFirstType: 'None',
      selectedSecondType: 'None',
      layout: 'Column',
      strongAttack: defaultTypes,
      weakAttack: defaultTypes,
      strongDefense: defaultTypes,
      weakDefense: defaultTypes,
      immuneDefense: defaultTypes
    };
  },
  updateValues: function(type, typeTwo) {
      var self = this;
      $.ajax('types/getStats', {
        data: { ElementOne: type, ElementTwo: typeTwo },
        success: function(data) {
          if(self.isMounted()) {
            self.setState({
              selectedFirstType: type,
              selectedSecondType: typeTwo,
              strongAttack: data.StrongAttack,
              weakAttack: data.WeakAttack,
              strongDefense: data.StrongDefense,
              weakDefense: data.WeakDefense,
              immuneDefense: data.ImmuneDefense
            });
          }
        }
      });
  },
  firstTypeChanged: function(newValue) {
    this.updateValues(newValue, this.state.selectedSecondType);
  },
  secondTypeChanged: function(newValue) {
    this.updateValues(this.state.selectedFirstType, newValue);
  },
  layoutChanged: function(newLayout) {
    this.setState({
      layout: newLayout
    });
  },
  render: function() {
    var rightSection;
    if(this.state.layout === 'Table') {
      rightSection = <TypesTableLayout />
    }
    else if(this.state.layout === 'Column') {
      rightSection = 
        <TypesColumnLayout
         strongAttack={this.state.strongAttack}
         weakAttack={this.state.weakAttack}
         strongDefense={this.state.strongDefense}
         weakDefense={this.state.weakDefense}
         immuneDefense={this.state.immuneDefense} />;
    }

    return (
      <div id="main">
        <TypeDropdown 
         types={this.state.types}
         selectedFirstType={this.state.selectedFirstType}
         selectedSecondType={this.state.selectedSecondType}
         firstTypeChanged={this.firstTypeChanged}
         secondTypeChanged={this.secondTypeChanged}  />
         <SwitchLayoutsSection onLayoutSwitch={this.layoutChanged} />
        <Sidebar
         types={this.state.types}
         selectedFirstType={this.state.selectedFirstType}
         selectedSecondType={this.state.selectedSecondType}
         firstTypeChanged={this.firstTypeChanged}
         secondTypeChanged={this.secondTypeChanged} />
         {rightSection}
      </div>
    );
  }
});

$(document).ready(function() {
  React.render(<TypeCalculator />, document.getElementById("mainContainer"));
});