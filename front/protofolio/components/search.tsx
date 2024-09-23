'use client';
import React, { useState } from "react";
import { SearchIcon } from 'lucide-react';
import { Button } from "./ui/button";
import { Avatar, AvatarFallback, AvatarImage } from "./ui/avatar";
import { Card, CardContent, CardHeader } from "./ui/card";
import { useEffect } from "react";
import { Input } from "./ui/input";

interface Topic {
    id: number;
    name: string;
    posts: number;
  }
  
  interface User {
    id: number;
    name: string;
    username: string;
    avatar: string;
  }


  export default function SearchPage () {
    const [searchQuery, setSearchQuery] = useState('');
    const [searchResults, setSearchResults] = useState<{ topics: Topic[], users: User[] }>({ topics: [], users: [] });
    const handleSearch = (e: React.FormEvent) => {
      e.preventDefault()
      // Simulated search results
      const topicResults = [
        { id: 1, name: 'React Hooks', posts: 120 },
        { id: 2, name: 'GraphQL', posts: 85 },
        { id: 3, name: 'TypeScript', posts: 200 },
      ].filter(topic => topic.name.toLowerCase().includes(searchQuery.toLowerCase()))
  
      const userResults = [
        { id: 1, name: 'John Doe', username: '@johndoe', avatar: '/placeholder-avatar.jpg' },
        { id: 2, name: 'Jane Smith', username: '@janesmith', avatar: '/placeholder-avatar.jpg' },
        { id: 3, name: 'Alice Williams', username: '@alicew', avatar: '/placeholder-avatar.jpg' },
      ].filter(user => user.name.toLowerCase().includes(searchQuery.toLowerCase()) || user.username.toLowerCase().includes(searchQuery.toLowerCase()))
  
      setSearchResults({ topics: topicResults, users: userResults })
    };
    return (
      <div className="space-y-6">
      <Card>
        <CardHeader>
          <h2 className="text-2xl font-bold">Search</h2>
        </CardHeader>
        <CardContent>
          <form onSubmit={handleSearch} className="space-y-4">
            <div className="flex space-x-2">
              <Input
                placeholder="Search for topics or users"
                value={searchQuery}
                onChange={(e) => setSearchQuery(e.target.value)}
                className="flex-1"
              />
              <Button type="submit">
                <SearchIcon className="w-4 h-4 mr-2" />
                Search
              </Button>
            </div>
          </form>
        </CardContent>
      </Card>

      {searchResults.topics.length > 0 && (
        <Card>
          <CardHeader>
            <h3 className="text-xl font-semibold">Topics</h3>
          </CardHeader>
          <CardContent>
            <div className="space-y-4">
              {searchResults.topics.map((topic) => (
                <div key={topic.id} className="flex justify-between items-center">
                  <div>
                    <h4 className="font-semibold">{topic.name}</h4>
                    <p className="text-sm text-gray-500">{topic.posts} posts</p>
                  </div>
                  <Button variant="outline" size="sm">Follow</Button>
                </div>
              ))}
            </div>
          </CardContent>
        </Card>
      )}

      {searchResults.users.length > 0 && (
        <Card>
          <CardHeader>
            <h3 className="text-xl font-semibold">Users</h3>
          </CardHeader>
          <CardContent>
            <div className="space-y-4">
              {searchResults.users.map((user) => (
                <div key={user.id} className="flex justify-between items-center">
                  <div className="flex items-center space-x-4">
                    <Avatar>
                      <AvatarImage src={user.avatar} alt={user.name} />
                      <AvatarFallback>{user.name[0]}</AvatarFallback>
                    </Avatar>
                    <div>
                      <h4 className="font-semibold">{user.name}</h4>
                      <p className="text-sm text-gray-500">{user.username}</p>
                    </div>
                  </div>
                  <Button variant="outline" size="sm">Follow</Button>
                </div>
              ))}
            </div>
          </CardContent>
        </Card>
      )}
    </div>
    )
  };