import React, { useEffect, useState } from 'react'
import { getRangePrices } from "../../Utils/ApiPrice";
import Typography from '@material-ui/core/Typography';
import Slider  from '@material-ui/core/Slider';
import { useDispatch, useSelector } from "react-redux";
import {readProducts} from "./../../Modules/Actions/ProductAction"


const PriceFilter = () => {
    const dispatch = useDispatch();
 
  // Our States
  const [value, setValue] =  useState([]);
  const [rangeValue, setRangeValue] =  useState([]);
  
  // Changing State when volume increases/decreases
  const rangeSelector = (event, newValue) => {
    setValue(newValue);
    dispatch( readProducts(1, null, value[0], value[1]))
  };

 useEffect(() => {
     getRangePrices()
       .then(({data}) => {
         setValue([data.minPrice, data.maxPrice])
         setRangeValue([data.minPrice, data.maxPrice])
      })},[]);
  
  return (
    <div 
     >
      <Typography id="range-slider" gutterBottom>
        Price Range:
      </Typography>
      <Slider
        value={value}
        min={rangeValue[0]}
        step={1}
        max={rangeValue[1]}
        onChangeCommitted={rangeSelector}
        valueLabelDisplay="auto"
        speed={500}
      />
      Range of Price is between {rangeValue[0]} M to {rangeValue[1]} M
    </div>
  );
}
  
export default PriceFilter;