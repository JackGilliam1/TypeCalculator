var $ = require('jquery.js');
var TypeDropdown = require('typeheader.jsx');
var TypesList = require('typeslist.jsx');
var TypesSection = require('typessection.jsx');
var React = require('react');

$(document).ready(function() {
  var firstType = 'None',
    secondType = 'None',
    setupTypeDropdown = function() {
      updateValues('None', 'None');
    },
    updateStrongAttack = function(strongAttack) {
      update(strongAttack, 'strong', 'attack', 'Strong Attack Against', 'left column');
    },
    updateWeakAttack = function(weakAttack) {
      update(weakAttack, 'weak', 'attack', 'Weak Attack Against', 'right column');
    },
    updateStrongDefense = function(strongDefense) {
      update(strongDefense, 'strong', 'defense', 'Strong Defense Against', 'left column');
    },
    updateWeakDefense = function(weakDefense) {
      update(weakDefense, 'weak', 'defense', 'Weak Defense Against', 'center column');
    },
    updateImmunities = function(immuneDefense) {
      update(immuneDefense, 'immune', 'defense', 'Immune Defense', 'right column');
    },
    update = function(elementTypes, id, section, columnTitle, className) {
      var selector = '.' + section + 'Section.' + id,
        i;

      if (!elementTypes || elementTypes.length === 0) {
        React.render(<TypesList types={["None"]} className={className} columnTitle={columnTitle} />, $(selector)[0]);
        return;
      }
      React.render(<TypesList types={elementTypes} className={className} columnTitle={columnTitle} />, $(selector)[0]);
      React.render(<TypesSection firstTypeChanged={typeOneChanged} secondTypeChanged={typeTwoChanged} selectedFirstType={firstType} selectedSecondType={secondType}/>, document.getElementById('leftSection'));
    },
    updateValues = function(type, typeTwo) {
      changeStatus('Updating');
      $.ajax('types/getStats', {
        data: { ElementOne: type, ElementTwo: typeTwo },
        success: function(data) {
          updateStrongAttack(data.StrongAttack);
          updateWeakAttack(data.WeakAttack);
          updateWeakDefense(data.WeakDefense);
          updateImmunities(data.ImmuneDefense);
          updateStrongDefense(data.StrongDefense);
          changeStatus('Updated');
        }
      });
    },
    typeOneChanged = function(e) {
      firstType = e.target.value || e.target.outerText;
      updateValues(firstType, secondType);
    },
    typeTwoChanged = function(e) {
      secondType = e.target.value || e.target.outerText;
      updateValues(firstType, secondType);
    },
    changeStatus = function(status) {
      React.render(<TypeDropdown firstTypeChanged={typeOneChanged} secondTypeChanged={typeTwoChanged} status={status} />, document.getElementById('typeDropdown'));
      React.render(<TypesSection firstTypeChanged={typeOneChanged} secondTypeChanged={typeTwoChanged} selectedFirstType={firstType} selectedSecondType={secondType} />, document.getElementById('leftSection'));
    };

    setupTypeDropdown();
});