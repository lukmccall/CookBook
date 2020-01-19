import { Client } from './client';
import { AuthControllerWrapper, TokenToAuth } from './wrappers';

export const ApiClient = new Client();

export const GetStaticUrl = file => {
  return `${ApiClient.baseUrl}${file}`;
};

export { AuthControllerWrapper, TokenToAuth };
