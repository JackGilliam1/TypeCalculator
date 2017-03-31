var React = require('react'),
    ReactDOM = require('react-dom'),
    $ = require('jquery'),
    TypeDropdown = require('typedropdown.jsx'),
    Sidebar = require('typesidebar.jsx'),
    TypesColumnLayout = require('typescolumnlayout.jsx'),
    TypesTableLayout = require('tablelayout/typestablelayout.jsx'),
    SwitchLayoutsSection = require('switchlayouts.jsx'),
    AddTypesForm = require('addtypesform.jsx'),
    TypeCalculator;

module.exports = TypeCalculator = React.createClass({
  displayName: 'TypeCalculator',
  getInitialState: function() {
    var defaultTypes = [];
    return {
      selectedAddType: 'strongAtk',
      selectedFirstType: 'None',
      selectedSecondType: 'None',
      layout: 'Table',
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
  selectedAddTypeChange: function (newValue) {
    this.setState({
      selectedAddType: newValue
    });
  },
  firstAndSecondTypeChanged: function(typeOne, typeTwo) {
    this.updateValues(typeOne, typeTwo);
  },
  layoutChanged: function(newLayout) {
    this.setState({
        layout: newLayout 
    });
  },
  typeAdded: function(typeOne, typeTwo, typeType) {
    //typeOne WeakDef, WeakAtk, StrongDef, StrongAtk, Immun
    //typeTwo Water, Fire, Grass, Custom...
    //typeName Water, Fire, Grass, Custom...
    var yes = typeOne;
  },
  render: function () {
    var rightSection;
    if(this.state.layout === 'Table') {
      rightSection = <TypesTableLayout
                       selectedFirstType={this.state.selectedFirstType}
                       selectedSecondType={this.state.selectedSecondType}
                       onCellClick={this.firstAndSecondTypeChanged} />
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
        <Sidebar
         types={this.state.types}
         selectedFirstType={this.state.selectedFirstType}
         selectedSecondType={this.state.selectedSecondType}
         firstTypeChanged={this.firstTypeChanged}
         secondTypeChanged={this.secondTypeChanged} />
         <SwitchLayoutsSection onLayoutSwitch={this.layoutChanged} defaultSelection={this.state.layout} />
         <AddTypesForm onAddTypes={this.typeAdded}
                       selectedAddType={this.state.selectedAddType}
                       addTypeChange={this.selectedAddTypeChange}/>
         {rightSection}
      </div>
    );
  }
});

$(document).ready(function() {
  ReactDOM.render(<TypeCalculator />, document.getElementById("mainContainer"));
});