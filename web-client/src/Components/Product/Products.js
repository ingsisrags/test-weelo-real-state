import React, { useEffect, useState } from 'react'
import { Container, Row, Col } from 'reactstrap';
import { getRangePrices } from "../../Utils/ApiPrice";
import CardItem from "../Card/CardItem";
import Wrapper from './../../Components/Hoc/Wrapper';
import PriceFilter from './../Filter/PriceFilter'
import SearchFilter from './../Filter/SearchFilter'
import { useDispatch, useSelector } from "react-redux";
import {readProducts} from "./../../Modules/Actions/ProductAction"
import { Link } from "react-router-dom";
import Card from "react-bootstrap/Card";


function Products() {
  const dispatch = useDispatch();
 
  useEffect(() => {
    const getProducts = () =>
      dispatch(
        readProducts(1)
      );
      getProducts();
  }, [
    
  ]);


  const products = useSelector((state) =>
   state.product.product
   );


  return(
    <Wrapper>
    <Container>
  <Row>
        <Col  lg="3">
        Filters
          <SearchFilter></SearchFilter>
          <hr/>
          <PriceFilter ></PriceFilter>
        </Col>
        <Col lg="9">
        <Link className="btn btn-sm btn-info" to={`/create-product/`}>Add new property</Link>
          <Row  style={{display: 'flex', flexWrap:'wrap'}} >
        {products? products.map(product => {
          return (
          <Col lg={4} md={6} sm={12} key={product.id}  style={{paddingTop:'1%'}} >
          < CardItem {...{product}}/>
          </Col>
        )
        }):""}
        
      </Row>
      </Col>
    </Row>
    </Container>
    </Wrapper>
 
    )
}

export default Products
