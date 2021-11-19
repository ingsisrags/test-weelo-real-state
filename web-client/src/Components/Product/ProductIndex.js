import React, { useEffect, useState } from 'react';
import { useHistory } from "react-router-dom";
import Carousel from 'react-bootstrap/Carousel'
import Container from "react-bootstrap/Container";
import Spinner from "react-bootstrap/Spinner";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Button from "react-bootstrap/Button";
import { useDispatch, useSelector } from "react-redux";
import { getProduct } from "../../Utils/ApiProduct";
import Row from "react-bootstrap/Row";
import FileUploaded from './../FileUpload/FileUploader';
import { useForm } from "react-hooks-helper";
import OwnerCreate from './OwnerCreate'
import CreateProduct from './ProductCreate'
import ProductCreate from './ProductCreate';
import ProductTrace from './ProductTrace';


function ProductIndex() {
  const defaultDataRealState = {
    Id: "",
    name: "",
    address: "",
    price: 0,
    codeInternal: 0,
    year: 0,
    image:"",
    owner: {
      Id: "",
      name: "",
      address: "",
      birthday: "",
      photo: ""
    },
    propertyTrace: []
  };
  const defaultOwner = {
    Id: "",
    name: "",
    address: "",
    birthday: ""
  }
  const defaultTraceProperty = {
    Id: "",
    datesale: "",
    name: "",
    value: 0,
    tax: 0
  };
  const [formProperty, setformProperty] = useState(defaultDataRealState);
  const [formOwner, setFormOwner] = useState(defaultOwner);
  const [saveOwner, setSaveOwner] = useState(false);
  const [saveProperty, setSaveProperty] = useState(false);
  const [saveTrace, setSaveTrace] = useState(false);
  const [formDataTraceProperty, setFormTraceProperty] = useForm(defaultTraceProperty);
  const [trace, setTrace] = useState([]);

    const traceProduct = useSelector((state) =>
    state.product.trace
    );

  const props = {
    formOwner, setFormOwner, formProperty, setformProperty, saveOwner, setSaveOwner,
    saveProperty, setSaveProperty, trace, setTrace, saveTrace, setSaveTrace
  };

  return (
    <div>
      {
        !saveOwner ?
          <OwnerCreate {...props}></OwnerCreate> :
          !saveProperty ?
            <ProductCreate {...props}></ProductCreate>
            :<ProductTrace {...props}></ProductTrace>
      }
    </div>
  )
}

export default ProductIndex
