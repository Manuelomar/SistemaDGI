import { api } from '../config';

const get = async (endpoint: string) => {
  return (await api.get(endpoint)).data;
}

const getById = async (endpoint: string, id: string) => {
  const url = `${endpoint}/${id}`;
  return (await api.get(url)).data;
}


export const http = {
  get,
  getById
}

