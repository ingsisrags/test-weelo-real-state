import { useState } from 'react';
import { useDispatch, useSelector } from "react-redux";
import {readProducts} from "./../../Modules/Actions/ProductAction"
function SearchFilter() {
  const [keyword, setKeyword] = useState('');
  const dispatch = useDispatch();

  const onChangeSearch = e =>{ 
    console.log(e.target)
    setKeyword(e.target.value)
    dispatch( readProducts(1, keyword, null, null))
  }

  return (
    <input 
    placeholder="Search"
    onChange={onChangeSearch}
    value={keyword}
  />
  );
}

export default SearchFilter;