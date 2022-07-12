import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import 'react-calendar/dist/Calendar.css';
import './app/layout/styles.css';
import App from './app/layout/App';
import { store, StoreContext } from './app/stores/store';
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <BrowserRouter>
    <StoreContext.Provider value={store}>
      <App />
    </StoreContext.Provider>
  </BrowserRouter>,
  document.getElementById('root')
);

reportWebVitals();
