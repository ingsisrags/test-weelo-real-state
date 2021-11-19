import React, { useEffect, useState } from 'react';
import { useHistory } from "react-router-dom";
import Carousel from 'react-bootstrap/Carousel'
import Container from "react-bootstrap/Container";
import Spinner from "react-bootstrap/Spinner";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Button from "react-bootstrap/Button";
import {UpdatePriceId} from "./../../Modules/Actions/ProductAction"
import { getProduct } from "../../Utils/ApiProduct";
import Row from "react-bootstrap/Row";
import { Avatar } from '@material-ui/core';
import UpdatePrice from './../Modals/UpdatePrice'
import { useDispatch, useSelector } from "react-redux";

function ProductDetails({ match }) {
    const dispatch = useDispatch();
    const [product, setProduct] = useState(null)
    const [productData, setProductData] = useState([])
    const [showModal, setShowModal] = useState(null)
    let history = useHistory();
    const handleClose = (event) => {
        setShowModal(false)
    }

    const handleShow = (event) => {
        setShowModal(true)
    }

    const savePrice = (event) => {
        console.log("updating..price",productData )
        const id = productData.id
        dispatch(UpdatePriceId(productData.id, productData.price));
        refreshPage();
    }

    function refreshPage() {
        window.location.reload(false);
      }

    useEffect(() => {
        getProduct(match.params.id)
            .then(({ data }) => {
                setProduct(data)
                setProductData(data)
                console.log("productId", data)
            })
    }, [getProduct, match.params.id])

 const props = {
    product, setProduct, showModal, setShowModal, handleClose, productData, setProductData, savePrice
  };




    return (
        <div className="py-3">
            <Container>
                {
                    product === null ?
                        (
                            <Spinner className="center" animation="border" />
                        ) :
                        (<Card style={{ padding: '3%', display: 'flex', flexWrap: 'wrap' }}  >
                            <Row >
                                <Col sm={8}>
                                    <Carousel style={{ height: "100%" }}>
                                        {product.propertyImage.length > 0 ? product.propertyImage.map(Image => {
                                            return (
                                                Image.base64 != undefined ? <Carousel.Item style={{ height: "100%" }}>
                                                    <img
                                                        className="d-block w-100"
                                                        src={"data:image/png;base64," + Image.base64}
                                                        alt=""
                                                    />
                                                </Carousel.Item>
                                                    : <Carousel.Item style={{ height: "100%" }}>
                                                        <img
                                                            className="d-block w-100"
                                                            src={"https://penmadsidrap.com/uploads/blog_image/default.jpg"}
                                                            alt=""
                                                        />
                                                    </Carousel.Item>

                                            );

                                        }) : <Carousel.Item style={{ height: "100%" }}>
                                            <img
                                                className="d-block w-100"
                                                src={"https://penmadsidrap.com/uploads/blog_image/default.jpg"}
                                                alt=""
                                            />
                                        </Carousel.Item>

                                        }
                                    </Carousel>
                                </Col>
                                <Col sm={4}>
                                    <div style={{ padding: '1%', display: 'flex', flexWrap: 'wrap' }} >
                                        <h5>{product.name} -   USD {product.price}</h5>
                                        <p>Address: {product.address}</p>
                                        <p>Building Year: {product.year}</p>
                                        <div>
                                            <Avatar style={{ minHeight: "110px", minWidth: '80px' }} src={"data:image/png;base64," + product.owner.photo}></Avatar>
                                            <p>Owner: {product.owner.name} </p>
                                            <p>Address: {product.owner.address}</p>
                                            <div>      <Button variant="primary" size="sm" onClick={handleShow}>Edit Price</Button></div>
                                        </div>
          
                                    </div>
                                </Col>
                            </Row>
                            <Card.Footer>
                                <Button variant="primary" size="sm" onClick={() => history.goBack()}>Back</Button>
                            </Card.Footer>
                        </Card>
                        )
                }
                {showModal?  <UpdatePrice {...props}></UpdatePrice>:""}
               
            </Container>

            

        </div>


    )
}

export default ProductDetails
