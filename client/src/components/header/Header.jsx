import React from "react";
import { Link } from "react-router-dom";

function Header() {
  return (
    <div className="ui one item menu">
      <div className="item">
        <Link to="/">Movey</Link>
      </div>
    </div>
  );
}

export default Header;
