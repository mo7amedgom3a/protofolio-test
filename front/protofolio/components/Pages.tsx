'use client'
import React from "react"
import { useState } from "react"
import { Button } from "@/components/ui/button"

import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle} from "./ui/card"
import { Avatar, AvatarFallback, AvatarImage } from "../components/ui/avatar";
import { Input } from "./ui/input"
import { Badge } from "@/components/ui/badge"
import { Textarea } from "./ui/textarea"
import { CiSearch } from "react-icons/ci";
import { SearchIcon } from "lucide-react"
const posts = [
    {
        id: 1,
        author: 'John Doe',
        avatar: '/placeholder-avatar.jpg',
        title: 'React Hooks',
        images: ['https://miro.medium.com/v2/resize:fit:1100/format:webp/0*QR-44Cl9I4Y7pUYQ'],
        lang: 'javascript',
        content: 'Just learned about React hooks. Game changer!',
        code: `const [count, setCount] = useState(0);
        
  useEffect(() => {
    document.title = \`You clicked \${count} times\`;
  }, [count]);`,
        likes: 42,
        comments: [
          { id: 1, author: 'Jane Smith', content: 'Totally agree! Hooks are amazing!' },
          { id: 2, author: 'Bob Johnson', content: 'Can you share more about how you\'re using them?' }
        ],
        saved: true,
        showComments: false,
      }
]
const notifications = [
    { id: 1, type: 'follow', user: 'Alice', time: '2h ago' },
    { id: 2, type: 'like', user: 'Bob', post: 'React hooks post', time: '3h ago' },
    { id: 3, type: 'comment', user: 'Charlie', post: 'GraphQL post', time: '5h ago' },
  ]
export const renderProfilePage = () => (
    <div className="space-y-6">
      <Card>
        <CardContent className="flex flex-col items-center space-y-4 pt-6">
          <Avatar className="w-24 h-24">
            <AvatarImage src="/placeholder-avatar.jpg" alt="Your Name" />
            <AvatarFallback>YN</AvatarFallback>
          </Avatar>
          <h2 className="text-2xl font-bold">Your Name</h2>
          <p className="text-gray-500">@yourusername</p>
          <p className="text-center max-w-md">
            Passionate developer with 5 years of experience in web technologies. Always eager to learn and share knowledge with the community.
          </p>
          <div className="flex space-x-4">
            <div className="text-center">
              <p className="font-bold">1.2k</p>
              <p className="text-sm text-gray-500">Followers</p>
            </div>
            <div className="text-center">
              <p className="font-bold">500</p>
              <p className="text-sm text-gray-500">Following</p>
            </div>
          </div>
        </CardContent>
      </Card>

      <Card>
        <CardHeader>
          <h3 className="text-lg font-semibold">Skills</h3>
        </CardHeader>
        <CardContent>
          <div className="flex flex-wrap gap-2">
            <Badge>JavaScript</Badge>
            <Badge>React</Badge>
            <Badge>Node.js</Badge>
            <Badge>TypeScript</Badge>
            <Badge>GraphQL</Badge>
            <Badge>Next.js</Badge>
            <Badge>TailwindCSS</Badge>
          </div>
        </CardContent>
      </Card>

      <Card>
        <CardHeader>
          <h3 className="text-lg font-semibold">Your Posts</h3>
        </CardHeader>
        <CardContent>
          <div className="space-y-4">
            {posts.filter(post => post.author === 'You').map((post) => (
              <Card key={post.id}>
                <CardHeader>
                  <h4 className="font-semibold">{post.content}</h4>
                </CardHeader>
                <CardContent>
                  {post.code && (
                    <pre className="bg-gray-100 p-4 rounded-md overflow-x-auto">
                      <code className="text-sm">{post.code}</code>
                    </pre>
                  )}
                </CardContent>
                <CardFooter>
                  <div className="flex space-x-4 text-sm text-gray-500">
                    <span>{post.likes} Likes</span>
                    <span>{post.comments.length} Comments</span>
                  </div>
                </CardFooter>
              </Card>
            ))}
          </div>
        </CardContent>
      </Card>
    </div>
  )

  export const renderNotificationsPage = () => (
    <Card>
      <CardHeader>
        <h2 className="text-2xl font-bold">Notifications</h2>
      </CardHeader>
      <CardContent>
        <div className="space-y-4">
          {notifications.map((notification) => (
            <div key={notification.id} className="flex items-center space-x-4">
              <Avatar>
                <AvatarFallback>{notification.user[0]}</AvatarFallback>
              </Avatar>
              <div>
                <p>
                  <span className="font-semibold">{notification.user}</span>{' '}
                  {notification.type === 'follow' && 'started following you'}
                  {notification.type === 'like' && `liked your post "${notification.post}"`}
                  {notification.type === 'comment' && `commented on your post "${notification.post}"`}
                </p>
                <p className="text-sm text-gray-500">{notification.time}</p>
              </div>
            </div>
          ))}
        </div>
      </CardContent>
    </Card>
  )

const handleSave = (postId: number) => {
  const postIndex = posts.findIndex(post => post.id === postId);
  if (postIndex !== -1) {
    posts[postIndex].saved = !posts[postIndex].saved;
  } else {
    console.error(`Post with id ${postId} not found`);
  }
}

export const renderSavedPostsPage = () => (
    <Card>
      <CardHeader>
        <h2 className="text-2xl font-bold">Saved Posts</h2>
      </CardHeader>
      <CardContent>
        <div className="space-y-4">
          {posts.filter(post => post.saved).map((post) => (
            <Card key={post.id}>
              <CardHeader>
                <div className="flex items-center space-x-4">
                  <Avatar>
                    <AvatarImage src={post.avatar} alt={post.author} />
                    <AvatarFallback>{post.author[0]}</AvatarFallback>
                  </Avatar>
                  <div>
                    <h3 className="text-lg font-semibold">{post.author}</h3>
                    <p className="text-sm text-gray-500">Posted 2 hours ago</p>
                  </div>
                </div>
              </CardHeader>
              <CardContent>
                <p>{post.content}</p>
                {post.code && (
                  <pre className="bg-gray-100 p-4 rounded-md overflow-x-auto mt-2">
                    <code className="text-sm">{post.code}</code>
                  </pre>
                )}
              </CardContent>
              <CardFooter>
                <div className="flex space-x-4 text-sm text-gray-500">
                  <span>{post.likes} Likes</span>
                  <span>{post.comments.length} Comments</span>
                </div>
              </CardFooter>
              <CardFooter className="flex justify-end">
                <Button variant="ghost" type="button" onClick={() => handleSave(post.id)}>
                  <p style={{color: "red"}}>unsave</p>
                </Button>
                </CardFooter>
            </Card>
          ))}
        </div>
      </CardContent>
    </Card>
  )
export  const renderSettingsPage = ()  => (
    <Card>
      <CardHeader>
        <h2 className="text-2xl font-bold">Account Settings</h2>
      </CardHeader>
      <CardContent>
        <form className="space-y-4">
          <div>
            <label htmlFor="username" className="block text-sm font-medium text-gray-700">Username</label>
            <Input id="username" defaultValue="yourusername" />
          </div>
          <div>
            <label htmlFor="email" className="block text-sm font-medium text-gray-700">Email</label>
            <Input id="email" type="email" defaultValue="you@example.com" />
          </div>
          <div>
            <label htmlFor="bio" className="block text-sm font-medium text-gray-700">Bio</label>
            <Textarea id="bio" defaultValue="Passionate developer with 5 years of experience in web technologies." />
          </div>
          <Button type="submit">Save Changes</Button>
        </form>
      </CardContent>
    </Card>
  )
