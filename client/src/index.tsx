import ReactDOM from 'react-dom';
import { BrowserRouter, Router } from 'react-router-dom';
import 'react-calendar/dist/Calendar.css';
import 'react-toastify/dist/ReactToastify.min.css';
import 'react-datepicker/dist/react-datepicker.css';
import './app/layout/styles.css';
import App from './app/layout/App';
import { store, StoreContext } from './app/stores/store';
import reportWebVitals from './reportWebVitals';
import { createBrowserHistory } from 'history';
import ScrollToTop from './app/layout/ScrollToTop';

export const history = createBrowserHistory();

ReactDOM.render(
  <BrowserRouter>
    <StoreContext.Provider value={store}>

      <Router history={history}>
        <ScrollToTop />
        <App />
      </Router>

    </StoreContext.Provider>
  </BrowserRouter>,
  document.getElementById('root')
);

reportWebVitals();
