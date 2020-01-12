import { ValidationFailedResponse, AuthFailedResponse } from './types';

export const AuthControllerWrapper = (task, callback, errorCallback) => {
  task()
    .then(data => callback(data))
    .catch(e => {
      if (e instanceof ValidationFailedResponse) {
        errorCallback(e.errors.map(x => x.messages).flatMap(x => x));
      } else if (e instanceof AuthFailedResponse) {
        errorCallback(e.errors);
      } else {
        errorCallback(['Unknown error.']);
      }
    });
};

export const TokenToAuth = token => {
  return `bearer ${token}`;
};
