# Streaming-Galaxy

## Introduction
This is a small system to get recommendations on movies based on a movies
you like.

## Parts
GraphGenerator => A subsystem that have all the graph implemetation. It can create,
delete, update or get data from a graph or a group of graphs.

HashBuilder => A subsystem that serializes and deserializes the data saved on the persisten storage,
this must be based on HashTables and must communicate with the GraphGenerator to build the graphs.

Basic CLI => basic command line interface for user usage.