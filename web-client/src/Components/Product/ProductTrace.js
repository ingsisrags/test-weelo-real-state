import React, { useEffect, useState, } from 'react';
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";
import CurrencyFormat from "react-currency-format";
import { useDispatch, useSelector } from "react-redux";
import {AddList} from "./../../Modules/Actions/ProductAction"
import Moment from 'moment';
import { Link } from "react-router-dom";
import {createProperty} from "./../../Modules/Actions/ProductAction"
const ProductTrace = props => {
    const defaultTrace = {
        Id: "",
        name: "",
        datesale: new Date(),
        value: 0,
        tax: ""
    }

    const {     formOwner, setFormOwner, formProperty, setformProperty, saveOwner, setSaveOwner,
        saveProperty, setSaveProperty, trace, setTrace, saveTrace, setSaveTrace } = props;
    const traceProduct = useSelector((state) =>
    state.product.trace
    );

    const [startDate, setStartDate] = useState(new Date());
    const [submitted, setSubmitted] = useState(false);
    const [newtrace, setnewtrace] = useState([]);
    const [traceunit, setTraceUnit] = useState(defaultTrace);
    const dispatch = useDispatch();
    const handleInputChange = (event) => {
        // console.log(event.target.name)
        // console.log(event.target.value)
        setTraceUnit({
            ...traceunit,
            [event.target.name]: event.target.value
        })
    }

    
    const handleSaveProperty = () => {
 
        formProperty.owner = formOwner;
        formProperty.propertyTrace = traceProduct;
        console.log("property",formProperty )
        dispatch(createProperty(formProperty))
      }

      const currenstate = useSelector((state) =>
      state
      );

    const handleAdd = (event) => {
        const newList = newtrace.concat(traceunit);
        setnewtrace(newList)
        console.log(newtrace);
        dispatch(
            AddList(newtrace)
          );
        
    }

    const handleChangeDate = (ev) => {
        setStartDate(ev);
       
        setTraceUnit({
              ...traceunit,
              datesale : ev
            });
    }

    const handleInputValue = (event) => {
        setTraceUnit({
             ...traceunit,
             value : event.value
        })
    }

    const handleInputTax = (event) => {
        setTraceUnit({
             ...traceunit,
             tax : event.value
        })
    }


    Moment.locale('en')

    return (
     
        <div className="submit-form">
            {saveTrace ? (
                <div>
                    <h4>You property was create successfully!</h4>
                    <div>
                     <Link className="btn btn-sm btn-info" to={`/create-product/`}>Add new property</Link>
                     </div>
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
                                    <div className="col-lg-12 col-sm-12">
                                        <div className="row">
                                            <div className="col-12">
                                                <label htmlFor="title">Name</label>
                                                <input
                                                    type="text"
                                                    className="form-control"
                                                    value={traceunit.name}
                                                    onChange={handleInputChange}
                                                    id="name"
                                                    required
                                                    name="name"
                                                />
                                            </div>
                                            <div className="col-6">
                                                <label htmlFor="title">Date Sale</label>
                                                <DatePicker
                                                    className="form-control"
                                                    id="datesale"
                                                    selected={startDate}
                                                    value={startDate}
                                                    onChange={(date) => setStartDate(date)}
                                                    name="datesale"
                                                />
                                            </div>
                                            <div className="col-3">
                                                <label htmlFor="title">Value</label>
                                                <CurrencyFormat
                                                    type="text"
                                                    className="form-control"
                                                    id="value"
                                                    value={traceunit.value}
                                                    decimalSeparator={','}
                                                    thousandSeparator={'.'}
                                                    name="value"
                                                    onValueChange={handleInputValue}
                                                />
                                            </div>
                                            <div className="col-3">
                                                <label htmlFor="title">Tax</label>
                                                <CurrencyFormat
                                                 type="text"
                                                    className="form-control"
                                                    id="tax"
                                                    value={traceunit.tax}
                                                    decimalSeparator={','}
                                                    thousandSeparator={'.'}
                                                    name="tax"
                                                    onValueChange={handleInputTax}
                                                />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div className="row">
                                    <div className="col-12">
                                        <button onClick={handleAdd} className="btn btn-success float-right">
                                            Add trace

                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div>
                                    <div className="table-responsive ">
                                        <table className="table ">
                                            <thead className="thead">
                                                <tr>
                                                    <th scope="col">Name</th>
                                                    <th scope="col">Date sale</th>
                                                    <th scope="col">Value</th>
                                                    <th scope="col">Tax</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {
                                                  traceProduct?.map(value =>{ return (

                                                        <tr>
                                                            <td  key={value.name} >{value?.name}</td>
                                                            <td>{Moment(value?.datesale).format('YYYY/MM/DD')}</td>
                                                            <td>{value?.value}</td>
                                                            <td>{value?.tax}</td>
                                                        </tr>
                                                  )
                                                })
                                                }
                                            </tbody>
                                        </table>
                                    </div>
                            </div>
                        </div>
                        <div className="card-footer">
                            <button onClick={handleSaveProperty} className="btn btn-success float-right">
                                Save
                            </button>
                        </div>
                    </div>


                </div>
            )
            }
        </div >
    )
}

export default ProductTrace