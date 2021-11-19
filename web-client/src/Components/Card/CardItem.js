import React from "react";
import { Link } from "react-router-dom";

import Card from "react-bootstrap/Card";

function CardItem(props) {
  const {id, name, price, owner, propertyImage, address } = props.product

  return (
    <Card style={{height: '100%'}}  >
      <Card.Img  src={ propertyImage[0] !=null?"data:image/png;base64,"+propertyImage[0].base64: "https://penmadsidrap.com/uploads/blog_image/default.jpg"}/>
      <Card.Body >
        <Card.Title>{name} - USD {price}</Card.Title>
            <Card.Text>
            <h6> Address :</h6> {address}
            </Card.Text>
      </Card.Body>
      <Card.Footer> <div className="d-flex justify-content-between align-items-center">
          <Link className="btn btn-sm btn-info" to={`/product/${id}`}>See details</Link>
        </div></Card.Footer>
    </Card>
  );
}

export default CardItem;
