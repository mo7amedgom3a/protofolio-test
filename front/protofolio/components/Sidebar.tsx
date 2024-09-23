'use client'
import React from "react";
// Sidebar.js
import { Avatar, AvatarFallback, AvatarImage } from "./ui/avatar";
import { Button } from "./ui/button";
import { ScrollArea } from "./ui/scroll-area";

const Sidebar = () => {
  return (
    <aside className="hidden md:block w-64 bg-white border-l border-gray-200 p-4">
      <h2 className="text-lg font-semibold mb-4">Who to Follow</h2>
      <ScrollArea className="h-[calc(100vh-8rem)]">
        {[...Array(10)].map((_, i) => (
          <div key={i} className="flex items-center justify-between mb-4">
            <div className="flex items-center gap-2">
              <Avatar>
                <AvatarImage src={`/placeholder-avatar.jpg`} alt={`User ${i + 1}`} />
                <AvatarFallback>{`U${i + 1}`}</AvatarFallback>
              </Avatar>
              <div>
                <p className="font-medium">User {i + 1}</p>
                <p className="text-sm text-gray-500">@user{i + 1}</p>
              </div>
            </div>
            <Button variant="outline" size="sm">Follow</Button>
          </div>
        ))}
      </ScrollArea>
    </aside>
  );
};

export default Sidebar;
