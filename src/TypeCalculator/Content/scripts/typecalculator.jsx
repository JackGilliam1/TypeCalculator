var $ = require('jquery.js');
var TypeDropdown = require('typecomponents.jsx');
var React = require('react');
$(document).ready(function() {
  var firstType = 'None',
    secondType = 'None';

  var setupTypeDropdown = function() {
    updateValues('None', 'None');
  },
    updateStrongAttack = function(strongAttack) {
      update(strongAttack, 'strong', 'attack');
    },
    updateWeakAttack = function(weakAttack) {
      update(weakAttack, 'weak', 'attack');
    },
    updateWeakDefense = function(weakDefense) {
      update(weakDefense, 'weak', 'defense');
    },
    updateImmunities = function(immuneDefense) {
      update(immuneDefense, 'immune', 'defense');
    },
    updateStrongDefense = function(strongDefense) {
      update(strongDefense, 'strong', 'defense');
    },
    update = function(elementTypes, id, section) {
      var selector = '#' + section + 'Section .' + id + ' .types',
        i;

      $(selector).html('');

      if (!elementTypes || elementTypes.length === 0) {
        $(selector).append('<span class="type displayInline none">None</span>');
        return;
      }

      for (i = 0; i < elementTypes.length; i++) {
        $(selector).append('<span class="type displayInline ' + elementTypes[i].toLowerCase() + '">' + elementTypes[i] + '</span>');
      }
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
      firstType = e.target.value;
      updateValues(firstType, secondType);
    },
    typeTwoChanged = function(e) {
      secondType = e.target.value;
      updateValues(firstType, secondType);
    },
    changeStatus = function(status) {
      React.render(<TypeDropdown firstTypeChanged={typeOneChanged} secondTypeChanged={typeTwoChanged} status={status} />, document.getElementById('typeDropdown'));
    };
    setupTypeDropdown();
  
  changeStatus('Updating');
});