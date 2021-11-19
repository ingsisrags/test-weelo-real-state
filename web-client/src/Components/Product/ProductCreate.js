import React, { useEffect, useState, } from 'react';
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";
import CurrencyFormat from "react-currency-format";
const ProductCreate = props => {
   const { formProperty, setformProperty,  saveProperty, setSaveProperty} = props;

    const [submitted, setSubmitted] = useState(false);
    const [startDate, setStartDate] = useState(new Date());
    const [file, setFile] = useState(new Date());
    const handleChange = (event) => {
        setFile(URL.createObjectURL(event.target.files[0]))
        setformProperty({
            ...formProperty,
            image : event.target.files[0]
        })
    }

    const handleInputChange = (event) => {
        setformProperty({
            ...formProperty,
            [event.target.name] : event.target.value
        })
    }

    const handleInputPrice = (event) => {
        console.log(event);
         setformProperty({
             ...formProperty,
             price : event.value
        })
    }

    console.log(formProperty);
    const setNameOwner= (e)=>{
        var data =e.target.value
    }

    const handleFile = (e) => {
        var reader = new FileReader();
        var file = e.target.files[0];

        reader.onload = function (upload) {
            this.setState({
                data_uri: upload.target.result,
            });
        }

        reader.readAsDataURL(file);
    }


    return (
        <div className="submit-form">
            {submitted ? (
                <div>
                    <h4>You submitted successfully!</h4>
                    <button className="btn btn-success">
                        Add
                    </button>
                </div>
            ) : (
                <div>
                    <hr />
                    <div className="card card-outline-secondary">
                        <div className="card-header">
                            <h3 className="mb-0">Property</h3></div>
                        <div className="card-body" >
                            <div className="form-group">
                                <div className="row">
                                <div className="col-12 col-md-3 col-lg-3 col-sm-12" >
                                        <div>
                                        <img style={{width:'100%', minHeight:'150px'}} src={file} />
                                        <input type="file" onChange={handleChange} />
                                        </div>
                                    </div>
                                    <div className="col-lg-8 col-sm-12">
                                        <div className="row">
                                            <div className="col-12">
                                                <label htmlFor="title">Name</label>
                                                <input
                                                    type="text"
                                                    className="form-control"
                                                    id="name"
                                                    required
                                                    value={formProperty.name}
                                                    onChange={handleInputChange}
                                                    name="name"
                                                />
                                            </div>
                                            <div className="col-6">
                                                <label htmlFor="title">Address</label>
                                                <input
                                                    type="text"
                                                    className="form-control"
                                                    id="address"
                                                    required
                                                    value={formProperty.address}
                                                    onChange={handleInputChange}
                                                    name="address"
                                                />
                                            </div>
                                            <div className="col-6">
                                            <label htmlFor="title">Price</label>
                                                <CurrencyFormat
                                                    type="text"
                                                    className="form-control"
                                                    id="price"
                                                    decimalSeparator={','}
                                                    thousandSeparator={'.'}
                                                    value={formProperty.price}
                                                    onValueChange={handleInputPrice}
                                                    name="price"
                                                />
                                            </div>

                                        </div>
                                    </div>
                                   
                                </div>

                            </div>
                        </div>
                        <div className="card-footer">
                        <button onClick={setSaveProperty} className="btn btn-success float-right">
                        Next
                    </button>
                    
                        </div>
                        </div>

                   
                </div>
            )
            }
        </div >
    )
}

export default ProductCreate