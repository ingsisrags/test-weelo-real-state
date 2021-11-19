import React, { useRef } from 'react'
import Modal from 'react-bootstrap/Modal'
import Button from "react-bootstrap/Button";
import CurrencyFormat from "react-currency-format";

const UpdatePrice = props => {
    const { showModal, setShowModal, handleClose, handleShow, product, setProduct, productData, setProductData, savePrice } = props;

    const handleInputPrice = (event) => {
        setProductData({
             ...productData,
             price : event.value
        })
    }
    console.log("productData", productData)
    return (
        <>
            <Modal show={showModal} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title> </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="row">
                        <div className="col-12">
                            <label htmlFor="title">{productData.name}</label>
                            <CurrencyFormat
                                                    type="text"
                                                    className="form-control"
                                                    id="price"
                                                    decimalSeparator={','}
                                                    thousandSeparator={'.'}
                                                    value={productData.price}
                                                    onValueChange={handleInputPrice}
                                                    name="price"
                                                />
                        </div>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={savePrice}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default UpdatePrice