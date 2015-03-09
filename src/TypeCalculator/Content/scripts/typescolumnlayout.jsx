var React = require('react');
var TypeColumn = require('typecolumn.jsx');

module.exports = React.createClass({
  displayName: 'TypesColumnLayout',
  propTypes: {
    strongAttack: React.PropTypes.arrayOf(React.PropTypes.string).isRequired,
    weakAttack: React.PropTypes.arrayOf(React.PropTypes.string).isRequired,
    strongDefense: React.PropTypes.arrayOf(React.PropTypes.string).isRequired,
    weakDefense: React.PropTypes.arrayOf(React.PropTypes.string).isRequired,
    immuneDefense: React.PropTypes.arrayOf(React.PropTypes.string).isRequired
  },
  render: function() {
    return (
      <div id="rightSection">
        <TypeColumn className={"attackSection strong type-column"} columnTitle="Strong Attack Against" types={this.props.strongAttack} />
        <TypeColumn className={"attackSection weak type-column"} columnTitle="Weak Attack Against" types={this.props.weakAttack} />
        <TypeColumn className={"defenseSection strong type-column"} columnTitle="Strong Defense Against" types={this.props.strongDefense} />
        <TypeColumn className={"defenseSection weak type-column"} columnTitle="Weak Defense Against" types={this.props.weakDefense} />
        <TypeColumn className={"defenseSection immune type-column"} columnTitle="Immune Defense" types={this.props.immuneDefense} />
      </div>
    );
  }
});